import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public userName:string = '';

  constructor(private router: Router) {}

  onSubmit() {
    this.router.navigateByUrl('/user/' + this.userName);
}
}
