import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ReactiveFormsModule, ValidatorFn, Validators } from '@angular/forms';
import { FirstKeyPipe } from "../../shared/pipes/first-key.pipe";
import { AuthService } from '../../shared/services/auth.service';
import { ToastrService } from 'ngx-toastr';
import { Router, RouterLink } from '@angular/router';

@Component({
  selector: 'app-registration',
  imports: [ReactiveFormsModule, CommonModule, FirstKeyPipe, RouterLink],
  templateUrl: './registration.component.html',
  styles: ``
})
export class RegistrationComponent implements OnInit {
  form: FormGroup;
  isSubmitted: boolean = false;

    passwordMatchValidator: ValidatorFn = (control: AbstractControl): null => {
      const password = control.get('password');
      const confirmPassword = control.get('confirmPassword');

      if (password && confirmPassword && password.value != confirmPassword.value)
        confirmPassword?.setErrors({passwordMismatch : true});
      else
        confirmPassword?.setErrors(null);

      return null;
  }

  constructor(
    public formBuilder: FormBuilder,
    private service: AuthService,
    private toastr: ToastrService,
    private router: Router
  ){
    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      dateOfBirth: ['', Validators.required],
      email: ['', [
        Validators.required, Validators.email
      ]],
      password: ['', [
        Validators.required,
        Validators.minLength(6),
        Validators.pattern(/(?=.*[^a-zA-Z0-9 ])/)
      ]],
      confirmPassword: [''],
    }, {validators: this.passwordMatchValidator});
  }
  
  ngOnInit(): void {
    if (this.service.isLoggedIn()) {
      this.router.navigateByUrl('/dashboard');
    }
  }

  onSubmit(){
    this.isSubmitted = true;

    if (this.form.valid) {
      this.service.createUser(this.form.value).subscribe({
        next: (res: any) => {
          if (res.succeeded) {
            this.form.reset();
            this.isSubmitted = false;
            this.toastr.success('New user created!', 'Registration successful');         
          }
        },
      error: err =>
        {
          if(err.error.errors)
          err.error.errors.forEach((x: any) => {
          switch(x.code){
            case "DuplicateUserName":
              break;

            case "DuplicateEmail":
              this.toastr.error('Email is already taken.', 'Registration Failed');
              break;

            default:
              this.toastr.error('Contact the developer', 'Registration Failed');
              console.log(x);
              break;
          }    
        })
        else
          console.log('error:', err);        
      }
    });
  }
  }

  hasDisplayableError(controlName : string) : Boolean {
    const control = this.form.get(controlName);

    return Boolean(control?.invalid) && (this.isSubmitted || Boolean(control?.touched) || Boolean(control?.dirty))
  }

}
