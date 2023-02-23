import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  public userName:string = '';
  public validation:boolean = false;

  constructor(private router: Router) {}

  onSubmit() {
    if(this.userName.trim() != '')
    {
      console.log("username:" +this.userName);
      this.router.navigateByUrl('/user/' + this.userName);     
    }
    else{
      this.validation = true;
    }
}
}
