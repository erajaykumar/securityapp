import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { SigninRedirectCallbackComponent } from './home/signin-redirect-callback.component';
import { SignoutRedirectCallbackComponent } from './home/signout-redirect-callback.component';
import { UnauthorizedComponent } from './home/unauthorized.component';
import { InsightDashboardComponent } from './insights/insight-dashboard/insight-dashboard.component';
import { AdvancedSettingsHomeComponent } from './advanced-settings/advanced-settings-home/advanced-settings-home.component';
import { AdminHomeComponent } from './admin/admin-home/admin-home.component';
import { NotificationHomeComponent } from './notification/notification-home/notification-home.component';
import { RuleComponent } from './rule/rule.component';
import { authGuard } from './core/auth.guard';
import { LoginComponent } from './login/login.component';
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'login', component: LoginComponent },
  { path: 'signin-callback', component: SigninRedirectCallbackComponent },
  { path: 'signout-callback', component: SignoutRedirectCallbackComponent },
  { path: 'rule', component: RuleComponent },
  {
    path: 'insight-dashboard',
    component: InsightDashboardComponent,
  },
  {
    path: 'advanced-settings',
    component: AdvancedSettingsHomeComponent,
  },
  {
    path: 'admin-home',
    component: AdminHomeComponent,
  },
  {
    path: 'notification-home',
    component: NotificationHomeComponent,
  },
  { path: 'unauthorized', component: UnauthorizedComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
