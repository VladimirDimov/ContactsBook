import { Component, Input, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styleUrls: ['./contact-details.component.scss'],
})
export class ContactDetailsComponent {
  private _contactId: number = 0;
  @Input()
  public get contactId(): number {
    return this._contactId;
  }

  public set contactId(value: number) {
    this._contactId = value;
  }

  @Output() contactIdChange = new EventEmitter<number>();
}
