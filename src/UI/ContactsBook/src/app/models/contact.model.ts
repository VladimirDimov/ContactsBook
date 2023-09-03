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

export class ContactModel implements ContactModel {
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
