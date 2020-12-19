import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TicketService } from '../services/ticket.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';



@Component({
  selector: 'app-home',
  templateUrl: './home.component.html'
})
export class HomeComponent {
  
//  public Tickets: Tacket[];

//  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
//    http.get<Tacket[]>(baseUrl + 'api/Tickets').subscribe(result => {
//      this.Tickets = result;
//    }, error => console.error(error));
//  }
//}
//interface Tacket {
//  Tic_Id: number;
//  Tic_Name: string;
//  Creationdatetime: string;
//  Status: boolean;
//  Content: string;
//  Laststatuschangesdatetime: string;
//  Userassigned: boolean;
//  }
  constructor(private _Service: TicketService) { }
  data: any;
  TicForm: FormGroup;
  submitted = false;
  EventValue: any = "Save";
  tic_Name: any;

  ngOnInit(): void {
    this.getdata();

    this.TicForm = new FormGroup({
      tic_Id: new FormControl(null),
      tic_Name: new FormControl("", [Validators.required]),
      creationdatetime: new FormControl("", [Validators.required]),
      laststatuschangesdatetime: new FormControl("", [Validators.required]),
      
    })
  }
  getdata() {
    this._Service.getData().subscribe((data: any[]) => {
      this.data = data;
    })
  }
  deleteData(id) {
    this._Service.deleteData(id).subscribe((data: any[]) => {
      this.data = data;
      this.getdata();
    })
  }
  Save() {
    this.submitted = true;

    if (this.TicForm.invalid) {
      return;
    }
    this._Service.postData(this.TicForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();

    })
  }
  Update() {
    this.submitted = true;

    if (this.TicForm.invalid) {
      return;
    }
    this._Service.putData(this.TicForm.value.tic_Id, this.TicForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();
    })
  }

  EditData(Data) {
    this.TicForm.controls["tic_Id"].setValue(Data.tic_Id);
    this.TicForm.controls["tic_Name"].setValue(Data.tic_Name);
    this.TicForm.controls["creationdatetime"].setValue(Data.creationdatetime);
    this.TicForm.controls["laststatuschangesdatetime"].setValue(Data.laststatuschangesdatetime);
    this.EventValue = "Update";
  }
  
  resetFrom() {
    this.getdata();
    this.TicForm.reset();
    this.EventValue = "Save";
    this.submitted = false;
  }
  //Filter
  Search() {
    if (this.tic_Name != "") {
      this.data = this.data.filter(res => {
        return res.tic_Name.toLowerCase().match(this.tic_Name.toLowerCase());
      })
    }
    else if (this.tic_Name == "") {
      this.ngOnInit();
    }
    
  }
  }
 
