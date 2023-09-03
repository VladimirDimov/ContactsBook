import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Store } from '@ngrx/store';
import { ContactCreateModel } from 'src/app/models/contact.model';
import { submitContactAction } from 'src/app/store/actions/contacts-book.actions';
import { ContactsBookStore } from 'src/app/store/reducer.interfaces';

@Component({
  selector: 'app-add-contact',
  templateUrl: './add-contact.component.html',
  styleUrls: ['./add-contact.component.scss'],
})
export class AddContactComponent implements OnInit {
  form: FormGroup<any> = new FormGroup({});

  constructor(private store: Store<ContactsBookStore>) {}

  ngOnInit(): void {
    this.form = new FormGroup({
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
  }

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

  onSubmit() {
    const formValue = this.form.value as ContactCreateModel;

    this.store.dispatch(submitContactAction({ value: formValue }));

    this.form.reset();
    this.close();
  }

  close() {
    this.visible = false;
  }
}
