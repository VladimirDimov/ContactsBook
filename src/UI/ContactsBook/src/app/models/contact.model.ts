export interface ContactCreateModel {
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  phoneNumber: Text;
  iban: string;
}

export interface ContactModel {
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  phoneNumber: Text;
  iban: string;
}

export interface AddressModel {
  id: number;
  title: string;
  country: string;
  city: string;
  street: string;
  number: string;
  contactId: number;
}
