import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { ConfirmationService, MessageService, TreeNode } from 'primeng/api';
import { Observable } from 'rxjs';
import { ContactModel } from 'src/app/models/contact.model';
import { loadContactsAction } from 'src/app/store/actions/contacts-book.actions';
import { increment, decrement } from 'src/app/store/actions/counter.actions';
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
  files!: TreeNode[];
  cols!: Column[];
  contacts$: Observable<any> = new Observable<any>();

  constructor(private store: Store<ContactsBookStore>) {}

  ngOnDestroy(): void {}

  ngOnInit(): void {
    this.cols = [
      { field: 'firstName', header: 'First Name' },
      { field: 'lastName', header: 'Last Name' },
      { field: 'dateOfBirth', header: 'Birth Date' },
    ];

    this.store.dispatch(loadContactsAction());
    this.contacts$ = this.store.select(contactsSelector);
    // this.contacts$.subscribe((contacts: ContactModel[]) => {
    //   this.files = contacts.map((c) => TreeNo);
    // });
  }

  addContact() {
    console.log('add contact clicked');
    this.visible = true;
  }

  public increment() {
    console.log('Increment');
    this.store.dispatch(increment({ value: 2 }));
  }
  public decrement() {
    console.log('Decrement');
    this.store.dispatch(decrement({ value: 2 }));
  }
}
