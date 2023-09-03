import { Component, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';

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
  }

  @Output() contactIdChange = new EventEmitter<number>();

  contactUpdateForm: FormGroup<any> = new FormGroup({});

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
  }

  onSubmit() {}
}
