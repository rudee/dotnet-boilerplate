import { Component, OnInit } from '@angular/core';
import { LoggingService } from '@app/core/logging.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {

  title = 'dotnet-boilerplate-presentation-web-angular';

  constructor(private loggingService: LoggingService) {
    this.loggingService = loggingService;
  }

  ngOnInit(): void {
    this.loggingService.log('AppComponent initialised');
  }
}
