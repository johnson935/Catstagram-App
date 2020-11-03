import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Cat } from 'src/models/cat';
import { CatService } from '../services/cat.service';

@Component({
  selector: 'app-list-cats',
  templateUrl: './list-cats.component.html',
  styleUrls: ['./list-cats.component.css']
})
export class ListCatsComponent implements OnInit {
  cats: Array<Cat>
  constructor(private catService: CatService, private router: Router) { }

  ngOnInit(): void {
    this.fetchCats();
  }

  routeToCat(id){
    this.router.navigate(["cats", id])
  }

  fetchCats() {
    this.catService.getCats().subscribe(cats => {
      this.cats = cats
    })
  }

  editCat(id){
    this.router.navigate(["cats/" + id +  "/edit"]);
  }

  deleteCat(id)
  {
    this.catService.deleteCat(id).subscribe(res => {
      this.fetchCats();
    })
  }
}
