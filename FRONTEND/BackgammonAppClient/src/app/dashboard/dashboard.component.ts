import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { TOKEN_KEY } from '../shared/constants';
import { AuthService } from '../shared/services/auth.service';
import { UserService } from '../shared/services/user.service';
import { HideIfClaimsNotMetDirective } from '../shared/directives/hide-if-claims-not-met.directive';
import { claimReq } from '../shared/utils/claimReq-utils';

@Component({
  selector: 'app-dashboard',
  imports: [HideIfClaimsNotMetDirective],
  templateUrl: './dashboard.component.html',
  styles: ``
})
export class DashboardComponent implements OnInit {
  constructor(
    private router: Router,
    private authService: AuthService,
    private userService: UserService
  ){ }

  fullName: string = '';
  claimReq = claimReq;  
  
  ngOnInit(): void {
    this.userService.getUserProfile().subscribe({
      next:(res: any) => this.fullName = res.firstName + ' ' + res.lastName,
      error:(err: any) => console.log('error while reaching user profile\n', err)
    });
  }

  onLogout(){
    this.authService.deleteToken();
    this.router.navigateByUrl('/signin');
  }
}
