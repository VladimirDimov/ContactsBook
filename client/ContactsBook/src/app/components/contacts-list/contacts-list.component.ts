import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { ConfirmationService, MessageService, TreeNode } from 'primeng/api';
import { Observable, map, pipe } from 'rxjs';
import { ContactModel } from 'src/app/models/contact.model';
import {
  deleteContactAction,
  loadContactsAction,
} from 'src/app/store/actions/contacts-book.actions';
import { ContactsBookStore } from 'src/app/store/reducer.interfaces';
import { contactsSelector } from 'src/app/store/selectors/contacts.selectors';

interface Column {
  field: string;
  header: string;
}

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.scss'],
  providers: [ConfirmationService, MessageService],
})
export class ContactsListComponent implements OnInit, OnDestroy {
  visible: boolean = false;
  detailsVisible: boolean = false;
  files!: TreeNode[];
  cols!: Column[];
  contacts$: Observable<any> = new Observable<any>();
  contacts: any[] = [];
  contactDetailsId: number = 0;

  constructor(private store: Store<ContactsBookStore>) {}

  ngOnDestroy(): void {}

  ngOnInit(): void {
    this.cols = [
      { field: 'firstName', header: 'First Name' },
      { field: 'lastName', header: 'Last Name' },
      { field: 'dateOfBirth', header: 'Birth Date' },
    ];

    this.store.dispatch(loadContactsAction());
    this.store
      .select(contactsSelector)
      .subscribe((contacts: ContactModel[]) => {
        this.contacts = contacts.map((c) => ({
          ...c,
          addressFormatted: c.address?.map((add) => ({
            title: add.title,
            address: [add.country, add.city, add.street, add.number]
              .filter((part) => !!part)
              .join(', '),
          })),
        }));
      });
  }

  addContact() {
    console.log('add contact clicked');
    this.visible = true;
  }

  onViewAddresses(contactId: number) {
    this.contactDetailsId = contactId;
    this.detailsVisible = true;
  }

  deleteContact(id: number) {
    this.store.dispatch(deleteContactAction({ value: id }));
  }
}
