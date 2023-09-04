import {
  Component,
  Input,
  Output,
  EventEmitter,
  OnInit,
  OnDestroy,
} from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { AddressModel, ContactModel } from 'src/app/models/contact.model';
import {
  createAddressAction,
  deleteAddressAction,
  getContactAddressesAction,
  getContactDetailsAction,
  updateContactAction,
} from 'src/app/store/actions/contacts-book.actions';
import { ContactsBookStore } from 'src/app/store/reducer.interfaces';
import {
  contactAddressesSelector,
  contactDetailsSelector,
} from 'src/app/store/selectors/contacts.selectors';
import { Observable, Subject, takeUntil } from 'rxjs';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.scss'],
})
export class ContactDetailsComponent implements OnInit, OnDestroy {
  private _contactId: number = 0;
  private onDestroy = new Subject<void>();

  @Input()
  public get contactId(): number {
    return this._contactId;
  }

  public set contactId(value: number) {
    this._contactId = value;
    this.addAddressForm.patchValue({ contactId: value });

    if (this._contactId > 0) {
      this.store.dispatch(
        getContactAddressesAction({ contactId: this.contactId })
      );
      this.store.dispatch(getContactDetailsAction({ value: this.contactId }));
    }
  }

  @Output() contactIdChange = new EventEmitter<number>();

  contactUpdateForm: FormGroup<any> = new FormGroup({});
  addAddressForm: FormGroup<any> = new FormGroup({});
  addresses$: Observable<AddressModel[]> = new Observable<AddressModel[]>();

  private _visible: boolean = false;
  @Input()
  public get visible(): boolean {
    return this._visible;
  }
  public set visible(value: boolean) {
    this._visible = value;
    this.visibleChange.emit(value);
  }
  @Output() visibleChange = new EventEmitter<boolean>();

  constructor(private store: Store<ContactsBookStore>) {}

  ngOnInit(): void {
    this.store
      .select(contactDetailsSelector)
      .pipe(takeUntil(this.onDestroy))
      .subscribe((contactDetails) => {
        const dateOfBirth = new Date(contactDetails.dateOfBirth);
        this.contactUpdateForm.patchValue({
          ...contactDetails,
          dateOfBirth: dateOfBirth,
        });
        console.log('loaded form:', this.contactUpdateForm);
      });

    this.contactUpdateForm = new FormGroup({
      id: new FormControl(this.contactId),
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

    this.initAddressForm();

    this.addresses$ = this.store.select(contactAddressesSelector);
  }

  ngOnDestroy(): void {
    this.onDestroy.next();
    this.onDestroy.complete();
  }

  updateContact() {
    if (!this.contactUpdateForm.valid)
      throw Error('Invalid update contact form');

    const updateModel = this.contactUpdateForm.value as ContactModel;
    this.store.dispatch(updateContactAction({ value: updateModel }));
    this.contactUpdateForm.markAsPristine();
  }

  addAddress() {
    const newAddress = this.addAddressForm.value as AddressModel;
    this.store.dispatch(createAddressAction({ value: newAddress }));
    this.addAddressForm.reset();
    this.initAddressForm();
  }

  deleteAddress(address: AddressModel) {
    this.store.dispatch(deleteAddressAction({ value: address.id }));
  }

  private initAddressForm() {
    this.addAddressForm = new FormGroup({
      contactId: new FormControl(this.contactId, [Validators.required]),
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
  }
}
