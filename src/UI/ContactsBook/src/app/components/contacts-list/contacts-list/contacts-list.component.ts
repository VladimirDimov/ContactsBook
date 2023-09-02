import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import {
  ConfirmEventType,
  ConfirmationService,
  MessageService,
} from 'primeng/api';
import { Observable } from 'rxjs';
import { increment, decrement } from 'src/app/store/actions/counter.actions';
import { ContactsBookStore } from 'src/app/store/reducer.interfaces';
import { selectCount } from 'src/app/store/selectors/counter.selectors';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.scss'],
  providers: [ConfirmationService, MessageService],
})
export class ContactsListComponent implements OnInit, OnDestroy {
  count$: Observable<number>;
  visible: boolean = false;

  constructor(
    private store: Store<ContactsBookStore>,
    private confirmationService: ConfirmationService,
    private messageService: MessageService
  ) {
    this.count$ = store.select(selectCount);
  }

  ngOnDestroy(): void {}

  ngOnInit(): void {}

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
