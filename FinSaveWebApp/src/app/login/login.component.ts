import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { finsaveService } from 'src/app/finsave.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  userdetails:any;
  constructor( private router: Router,private _formBuilder: FormBuilder ,public finsaveService:finsaveService) { 
    localStorage.removeItem('currentuser');
  }
 
  loginForm: FormGroup;
  ngOnInit(): void {
    localStorage.removeItem('currentuser');
    this.loginForm = this._formBuilder.group({
      username   : ['', [Validators.required]],
      password: ['', Validators.required]
  });
  }
  LoginUser(): void{
    var userName = this.loginForm.get("username").value;
    var payload = {      
      UserName: userName,
      Password: this.loginForm.get("password").value
    }
    
     this.finsaveService.LoginUser(payload).subscribe(res=>{
      console.log(res);
      let jsonString = JSON.stringify(res);
      localStorage.setItem('currentuser', jsonString);
      if(userName == 'admin'){
        this.router.navigate(['admindashboard']);
      }
      else{
      this.router.navigate(['dashboard']);
      }
    });
   
   
  }
}
