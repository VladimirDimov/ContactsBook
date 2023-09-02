import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ContactCreateModel } from '../models/contact.model';
import { configurations } from '../configurations';

@Injectable()
export class ApiClientService {
  private baseUrl = configurations.apiBaseUrl;

  constructor(private http: HttpClient) {}

  addNewContact(contact: ContactCreateModel) {
    this.http
      .post(this.baseUrl + '/contacts', contact)
      .subscribe((response) => {
        console.log('response: ', response);
      });
  }

  getAllContacts() {
    this.http.get(this.baseUrl + '/contacts').subscribe((response) => {
      console.log('response: ', response);
    });
  }
}
