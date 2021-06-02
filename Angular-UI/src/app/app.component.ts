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

  public getLastId() {
    var max = 0, x;
    for( x in this.currEntries) {
      if( this.currEntries[x].id > max) max = this.currEntries[x].id;
    }
    return max;
  }

  public addEntry() {
    if (this.currEntries != null) {
      this.currEntries.push({
        id: this.getLastId() + 1
      });
    }
  }

  public deleteEntry(index: any) {
    console.log(this.currEntries);
    this.http.post(this.apiURL + "delete", this.currEntries[index].id).subscribe((res:any) => {
      if (res) {
        this.currEntries.splice(index,1);
      }
    })
  }

  public scrubEntries() {
      this.currEntries = this.currEntries.filter(item => (item.date));
  }

  public runPayroll() {
    // on payroll button click
    var header = new HttpHeaders({ 'content-type': 'application/json; charset=utf-8', 'dataType': 'json'});
    this.scrubEntries();
    var entries = JSON.stringify({"entries": this.currEntries});
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
    // Popup displaying hours info
    this._snackBar.open(message, "close", {
      duration: 8000,
      panelClass: ['success-snackbar']
    });
  }
}
