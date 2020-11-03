import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Cat } from 'src/models/cat';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {

  catForm: FormGroup;
  catId: string;  
  cat: Cat;
  constructor(private fb: FormBuilder, private route: ActivatedRoute, 
    private catService: CatService,
    private router: Router) {
    this.catForm = this.fb.group({
      'id': [''],
      'description': ['']
    });
   }

  ngOnInit(): void {
    this.route.params.subscribe(params => {
      this.catId = params['id'];
      this.catService.getCat(this.catId).subscribe(res =>
        {
          this.cat = res;
          this.catForm = this.fb.group({
            'id': [this.cat.id],
            'description': [this.cat.description]
          })
        })
    })
  }

  editCat(){
    this.catService.editCat(this.catForm.value).subscribe(res =>{
      this.router.navigate(['cats']);
    })
  }
}
