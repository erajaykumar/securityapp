import { Component } from '@angular/core';
import { Breakpoints, BreakpointObserver } from '@angular/cdk/layout';
import { Layout } from 'src/app/models/layout.model';
import { map, merge, Observable } from 'rxjs';

@Component({
  selector: 'app-grid-list',
  templateUrl: './grid-list.component.html',
  styleUrls: ['./grid-list.component.scss'],
})
export class GridListComponent {
  cardsLayout: Observable<Layout>;

  constructor(private breakpointObserver: BreakpointObserver) {
    this.cardsLayout = merge(
      this.breakpointObserver.observe([Breakpoints.Handset, Breakpoints.XSmall, Breakpoints.Small]).pipe(
        map(({ matches }) => {
          if (matches) {
            console.debug('👉🏽 handset layout activated',);
            return this.getHandsetLayout();
          }
          return this.getDefaultLayout();
        })),
      this.breakpointObserver.observe(Breakpoints.Tablet).pipe(
        map(({ matches }) => {
          if (matches) {
            console.debug('👉🏽  tablet layout activated', this.cardsLayout);
            return this.getTabletLayout();
          }
          return this.getDefaultLayout();
        })),
      this.breakpointObserver.observe(Breakpoints.Web).pipe(
        map(({ matches }) => {
          if (matches) {
            console.debug('👉🏽  web layout activated', this.cardsLayout);
            return this.getWebLayout();
          }
          return this.getDefaultLayout();
        }))
    );

  }

  getHandsetLayout(): Layout {
    return {
      name: 'Handset',
      gridColumns: 1
    };
  }

  getTabletLayout(): Layout {
    return {
      name: 'Tablet',
      gridColumns: 2
    };
  }

  getWebLayout(): Layout {
    return {
      name: 'Web',
      gridColumns: 4
    };
  }

  getDefaultLayout() {
    return {
      name: 'default',
      gridColumns: 1
    };
  }

}
