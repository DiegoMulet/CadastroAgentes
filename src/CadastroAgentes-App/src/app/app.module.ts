import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BsDropdownModule, TooltipModule, ModalModule, TabsModule, BsDatepickerModule  } from 'ngx-bootstrap';
import {NgxMaskModule} from 'ngx-mask';
import { AppRoutingModule } from './app-routing.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ToastrModule } from 'ngx-toastr';
import { NgxCurrencyModule } from 'ngx-currency';

import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { TituloComponent } from './_shared/titulo/titulo.component';
import { ClientesComponent } from './clientes/clientes.component';
import { FornecedoresComponent } from './fornecedores/fornecedores.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './user/login/login.component';
import { RegistrationComponent } from './user/registration/registration.component';

import { ClienteService } from './_services/cliente.service';
import { AuthInterceptor } from './auth/auth.interceptor';

@NgModule({
   declarations: [
      AppComponent,
      NavComponent,
      TituloComponent,
      ClientesComponent,
      FornecedoresComponent,
      UserComponent,
      LoginComponent,
      RegistrationComponent
   ],
   imports: [
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      FormsModule,
      BsDropdownModule.forRoot(),
      BsDatepickerModule.forRoot(),
      TooltipModule.forRoot(),
      ModalModule.forRoot(),
      ReactiveFormsModule,
      BrowserAnimationsModule,
      TabsModule.forRoot(),
      ToastrModule.forRoot({
         timeOut: 10000,
         positionClass: 'toast-bottom-right',
         preventDuplicates: true,
       }),
       NgxMaskModule.forRoot(),
       NgxCurrencyModule
   ],
   providers: [
      ClienteService,
      {
         provide: HTTP_INTERCEPTORS,
         useClass: AuthInterceptor,
         multi: true
      }
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
