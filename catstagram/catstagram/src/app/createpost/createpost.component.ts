import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { CatService } from '../services/cat.service';
@Component({
  selector: 'app-createpost',
  templateUrl: './createpost.component.html',
  styleUrls: ['./createpost.component.css']
})
export class CreatepostComponent implements OnInit {
  catForm : FormGroup;
  constructor(private fb: FormBuilder, 
    private catService: CatService,
    private toastrService: ToastrService) { 
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
    this.catService.create(this.catForm.value)
    .subscribe(res => {
      this.toastrService.success("Success");
    })
  }
}
