export interface ContactCreateModel {
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  phoneNumber: Text;
  iban: string;
}

export interface ContactModel {
  id: number;
  firstName: string;
  lastName: string;
  dateOfBirth: Date;
  phoneNumber: Text;
  iban: string;
}

export class ContactModel implements ContactModel {
  public id!: number;
  public firstName!: string;
  public lastName!: string;
  public dateOfBirth!: Date;
  public phoneNumber!: Text;
  public iban!: string;
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
