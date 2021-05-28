import { Component } from '@angular/core';
import { HttpClient, HttpResponse, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, Subject, BehaviorSubject} from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Angular-UI';

  apiURL = "https://localhost:5001/api/form/"
  currEntries: any [] = [];
  value = 'Clear me';

  constructor(
    public http: HttpClient
  ) {}

  ngOnInit(): void {
    this.get(this.apiURL + "gettimesheetentries").subscribe((res: any) => {
      console.log(res);
      this.currEntries = res.timeEntries;
    });
  }

  public get<T>(url: string, params?: any): Observable<T> {
    return this.http.get<T>(url, {params: params});
  }

  public addEntry() {
    if (this.currEntries != null) {
      this.currEntries.push({});
    }
  }

  public runPayroll() {
    // on payroll button click
  }
}
