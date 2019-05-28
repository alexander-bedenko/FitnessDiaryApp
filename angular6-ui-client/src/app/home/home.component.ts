import { Component, OnInit, Input } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '../_models';
import { UserService } from '../_services';
import { LoginComponent } from '../login';
import { MatDialog } from '@angular/material';

@Component(
    {
        templateUrl: 'home.component.html'
    })
    
export class HomeComponent implements OnInit {
    currentUser: User;
    users: User[] = [];
    closeResult: string;
    data: string;

    constructor(private userService: UserService, public dialog: MatDialog) {
        this.currentUser = JSON.parse(localStorage.getItem('currentUser'));
    }

    ngOnInit() {
        this.loadAllUsers();
    }

    deleteUser(id: number) {
        this.userService.delete(id).pipe(first()).subscribe(() => { 
            this.loadAllUsers() 
        });
    }

    // openDialog() {
    //   const dialogRef = this.dialog.open(LoginComponent);
    // }

    private loadAllUsers() {
        this.userService.getAll().pipe(first()).subscribe(users => { 
            this.users = users; 
        });
    }
}