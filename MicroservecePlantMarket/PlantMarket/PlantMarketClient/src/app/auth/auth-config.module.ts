import { NgModule } from '@angular/core';
import { AuthModule } from 'angular-auth-oidc-client';
import { LogLevel } from 'angular-auth-oidc-client';


@NgModule({
    imports: [
        AuthModule.forRoot({
        config: {
            clientId: 'angular',
            authority: 'https://localhost:6001',
            responseType: 'code',
            redirectUrl: window.location.origin,
            postLogoutRedirectUri: window.location.origin,
            scope: 'openid profile ProductApi OrderApi ShopCartApi',  // profile  
            //silentRenew: true,
            //useRefreshToken: true,
            logLevel: LogLevel.Debug,
          }
      })],
    exports: [AuthModule],
})
export class AuthConfigModule {}
