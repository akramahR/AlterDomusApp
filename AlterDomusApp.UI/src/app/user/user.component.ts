import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent {
  public user?: User;
  public showRecommendation:boolean = false;
  public recommendations:Array<string> =[];

  constructor(private http: HttpClient,private route: ActivatedRoute) {}

  ngOnInit() {
    const userLogin: string = this.route.snapshot.params['userLogin'];

    console.log("sending req:" + userLogin);
    this.http.get<User>('/api/Github?userLogin=' + userLogin).subscribe(result => {
      this.user = result;
    
    
    var length = 0;
    console.log(this.user);
    if(this.user?.bio === null){
      length = this.recommendations.push("Add your bio to the profile");
    }
    if(this.user?.company === null){
      length = this.recommendations.push("Add your Company to the profile");
    }
    if(this.user?.location === null){
      length = this.recommendations.push("Add your Location to the profile");
    }
    if(this.user?.repositoryCount<5 ){
      length = this.recommendations.push("Create some more projects");
    }
    if(this.user?.following<5 ){
      length = this.recommendations.push("Follow some more developers");
    }
    console.log(this.recommendations);
    this.showRecommendation = length > 0;

  }, error => console.error(error));
  }
}

interface User{
  login: string;
  bio: string;
  company:string;
  location:string;
  avatarUrl:string;
  repositoryCount:number;
  following:number;
}
