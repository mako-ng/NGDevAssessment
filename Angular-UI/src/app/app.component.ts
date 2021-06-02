import { Component } from '@angular/core';
import { HttpClient, HttpResponse, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable, Subject, BehaviorSubject} from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';

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
    public http: HttpClient,
    private _snackBar: MatSnackBar
  ) {}

  ngOnInit(): void {
    this.get(this.apiURL + "gettimesheetentries").subscribe((res: any) => {
      console.log(typeof(res));
      console.log(typeof(res.timeEntries));
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

  public deleteEntry() {

  }

  public runPayroll() {
    // on payroll button click
    const params = new URLSearchParams();
    var header = new HttpHeaders({ 'content-type': 'application/json; charset=utf-8', 'dataType': 'json'});
    var entries = JSON.stringify({"entries": this.currEntries});
    console.log(entries);
    this.http.post(this.apiURL + "update", entries, { headers: header }).subscribe((res: any) => {
      console.log(res);
      if (res) {
        this.http.get(this.apiURL + "runpayroll").subscribe((res:any) => {
          console.log(res);
          this.openSnackBar('Regular Hours: ' + res.regularHours + '\n' + 'Overtime Hours: ' + res.overtimeHours);
        });
      }
    });
  }

  openSnackBar(message: string) {
    this._snackBar.open(message, "close", {
      duration: 8000,
      panelClass: ['success-snackbar']
    });
  }
}
