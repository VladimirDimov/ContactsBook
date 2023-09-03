import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AddressModel } from 'src/app/models/contact.model';
import { getContactAddressesAction } from 'src/app/store/actions/contacts-book.actions';
import { ContactsBookStore } from 'src/app/store/reducer.interfaces';
import { contactAddressesSelector } from 'src/app/store/selectors/contacts.selectors';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.scss'],
})
export class ContactDetailsComponent implements OnInit {
  private _contactId: number = 0;

  @Input()
  public get contactId(): number {
    return this._contactId;
  }

  public set contactId(value: number) {
    this._contactId = value;
    this.visible = value != 0;

    if (this._contactId !== 0) {
      this.store.dispatch(
        getContactAddressesAction({ contactId: this.contactId })
      );
    }
  }

  @Output() contactIdChange = new EventEmitter<number>();

  contactUpdateForm: FormGroup<any> = new FormGroup({});
  addAddressForm: FormGroup<any> = new FormGroup({});
  addresses$: Observable<AddressModel[]> = new Observable<AddressModel[]>();
  visible: boolean = false;

  constructor(private store: Store<ContactsBookStore>) {}

  ngOnInit(): void {
    this.contactUpdateForm = new FormGroup({
      firstName: new FormControl(null, [
        Validators.required,
        Validators.maxLength(30),
      ]),
      lastName: new FormControl(null, [
        Validators.required,
        Validators.maxLength(30),
      ]),
      dateOfBirth: new FormControl(null),
      phoneNumber: new FormControl(null, [
        Validators.required,
        Validators.maxLength(20),
      ]),
      iban: new FormControl(null, [Validators.maxLength(34)]),
    });

    this.addAddressForm = new FormGroup({
      title: new FormControl(null, [
        Validators.required,
        Validators.maxLength(30),
      ]),
      country: new FormControl(null, [
        Validators.required,
        Validators.maxLength(30),
      ]),
      city: new FormControl(null, [
        Validators.required,
        Validators.maxLength(30),
      ]),
      street: new FormControl(null, [
        Validators.required,
        Validators.maxLength(30),
      ]),
      number: new FormControl(null, [Validators.maxLength(20)]),
    });

    this.addresses$ = this.store.select(contactAddressesSelector);
  }

  onSubmit() {}
}
