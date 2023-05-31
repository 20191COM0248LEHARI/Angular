import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavResComponent } from './Components/nav-res/nav-res.component';
import { CheckoutComponent } from './Components/checkout/checkout.component';
import { HomepageComponent } from './Components/homepage/homepage.component';

@NgModule({
  declarations: [
    AppComponent,
    NavResComponent,
    CheckoutComponent,
    HomepageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
