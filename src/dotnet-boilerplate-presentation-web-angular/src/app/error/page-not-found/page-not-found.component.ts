import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-page-not-found',
  templateUrl: './page-not-found.component.html',
  styleUrls: ['./page-not-found.component.scss']
})

export class PageNotFoundComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
    // console.log('Not Found');
    // console.warn('Not Found');
    // console.error('Not Found');
    throw Error('this is an error');
  }

}
