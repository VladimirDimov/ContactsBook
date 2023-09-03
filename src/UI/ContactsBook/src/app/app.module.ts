import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuModule } from 'primeng/menu';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MegaMenuModule } from 'primeng/megamenu';
import { MenubarModule } from 'primeng/menubar';
import { HeaderComponent } from './components/header/header/header.component';
import { StoreModule } from '@ngrx/store';
import { ContactsBookStore } from './store/reducer.interfaces';
import { EffectsModule } from '@ngrx/effects';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
import { DialogModule } from 'primeng/dialog';
import { AddContactComponent } from './components/add-contact/add-contact.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ContatsBookEffects } from './store/effects/contacts-book.effects';
import { ApiClientService } from './shared/api-client.service';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { TreeTableModule } from 'primeng/treetable';
import { contactsReducer } from './store/contacts.reducer';
import { TableModule } from 'primeng/table';
import { ContactsListComponent } from './components/contacts-list/contacts-list.component';
import { ContactDetailsComponent } from './components/contact-details/contact-details.component';
import { CardModule } from 'primeng/card';
import { CalendarModule } from 'primeng/calendar';
import { ToastModule } from 'primeng/toast';
import { MessageService } from 'primeng/api';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    ContactsListComponent,
    AddContactComponent,
    ContactDetailsComponent,
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    MenuModule,
    MegaMenuModule,
    MenubarModule,
    ConfirmDialogModule,
    DialogModule,
    ReactiveFormsModule,
    TreeTableModule,
    TableModule,
    CardModule,
    CalendarModule,
    ToastModule,
    StoreModule.forRoot({
      contactStore: contactsReducer,
    }),
    EffectsModule.forRoot([ContatsBookEffects]),
  ],
  providers: [ApiClientService, HttpClient, MessageService],
  bootstrap: [AppComponent],
})
export class AppModule {}
