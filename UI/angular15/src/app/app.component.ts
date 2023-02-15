import { Component } from '@angular/core';
import { ActivatedRoute, NavigationEnd, Router, RouterEvent, Event  } from '@angular/router';
import { filter, map, Observable } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent {

  constructor(private router: Router, private readonly route: ActivatedRoute,) {

    this.router.events.subscribe((event: Event) => {
      if (event instanceof NavigationEnd) 
      {
        this.hasHeader = event.url.includes('admin');
      }
    })
  }

  title = 'angular15';

  hasHeader: boolean = true;
}
