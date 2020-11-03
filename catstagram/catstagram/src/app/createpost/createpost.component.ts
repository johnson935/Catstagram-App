import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { CatService } from '../services/cat.service';
@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {
  catForm : FormGroup;
  constructor(private fb: FormBuilder, private catService: CatService) { 
    this.catForm = this.fb.group({
      'ImageUrl': ['',Validators.required],
      'Description': ['']
    })
  }

  ngOnInit(): void {
  }

  get imageUrl(){
    return this.catForm.get('ImageUrl');
  }

  create(){
    
  }
}
