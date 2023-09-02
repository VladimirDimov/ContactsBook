import { Component, OnInit, OnDestroy } from '@angular/core';
import { Store } from '@ngrx/store';
import { Observable } from 'rxjs';
import { increment, decrement } from 'src/app/store/actions/counter.actions';
import { ContactsBookStore } from 'src/app/store/reducer.interfaces';
import { selectCount } from 'src/app/store/selectors/counter.selectors';

@Component({
  selector: 'app-contacts-list',
  templateUrl: './contacts-list.component.html',
  styleUrls: ['./contacts-list.component.scss'],
})
export class ContactsListComponent implements OnInit, OnDestroy {
  count$: Observable<number>;

  constructor(private store: Store<ContactsBookStore>) {
    this.count$ = store.select(selectCount);
  }

  ngOnDestroy(): void {}

  ngOnInit(): void {}

  public increment() {
    console.log('Increment');
    this.store.dispatch(increment({ value: 2 }));
  }
  public decrement() {
    console.log('Decrement');
    this.store.dispatch(decrement({ value: 2 }));
  }
}
