import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { AddressModel, ContactCreateModel } from '../models/contact.model';
import { configurations } from '../configurations';
import { Observable } from 'rxjs';

@Injectable()
export class ApiClientService {
  private baseUrl = configurations.apiBaseUrl;

  constructor(private http: HttpClient) {}

  addNewContact(contact: ContactCreateModel): Observable<any> {
    return this.http.post(this.baseUrl + '/contacts', contact);
  }

  getAllContacts(): Observable<any> {
    return this.http.get(this.baseUrl + '/contacts');
  }

  getContactAddresses(contactId: number): Observable<any> {
    return this.http.get(this.baseUrl + `/contacts/addresses/${contactId}`);
  }

  addNewAddress(address: AddressModel): Observable<any> {
    return this.http.post(this.baseUrl + '/addresses', address);
  }
}
