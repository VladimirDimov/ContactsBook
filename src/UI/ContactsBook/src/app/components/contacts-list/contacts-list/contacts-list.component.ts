import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import {
  ConfirmEventType,
  ConfirmationService,
  MessageService,
  TreeNode,
} from 'primeng/api';
import { Observable, tap } from 'rxjs';
import { loadContactsAction } from 'src/app/store/actions/contacts-book.actions';
import { increment, decrement } from 'src/app/store/actions/counter.actions';
import { ContactsBookStore } from 'src/app/store/reducer.interfaces';
import { contactsSelector } from 'src/app/store/selectors/contacts.selectors';
import { selectCount } from 'src/app/store/selectors/counter.selectors';

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
  count$: Observable<number>;
  visible: boolean = false;
  files!: TreeNode[];
  cols!: Column[];
  contacts$: Observable<any> = new Observable<any>();

  constructor(
    private store: Store<ContactsBookStore>,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {
    this.count$ = store.select(selectCount);
  }

  ngOnDestroy(): void {}

  ngOnInit(): void {
    this.cols = [
      { field: 'name', header: 'Name' },
      { field: 'size', header: 'Size' },
      { field: 'type', header: 'Type' },
    ];

    this.store.dispatch(loadContactsAction());
    this.contacts$ = this.store.select(contactsSelector);
    this.contacts$.subscribe((res) => {
      debugger;
    });
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
