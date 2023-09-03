import { AddressModel, ContactModel } from '../models/contact.model';

export interface ContactsBookStore {
  contacts: ContactModel[];
  contactAddresses: AddressModel[];
  contactDetails: ContactModel;
}
