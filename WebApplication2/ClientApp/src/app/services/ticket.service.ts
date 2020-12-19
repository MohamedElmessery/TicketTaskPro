import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TicketService {

  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  getData() {

    return this.http.get('/api/Tickets');  
  }

  postData(formData) {
    return this.http.post('/api/Tickets', formData);
  }

  putData(id, formData) {
    return this.http.put('/api/Tickets/' + id, formData);
  }
  deleteData(id) {
    return this.http.delete('/api/Tickets/' + id);
  }

}  

