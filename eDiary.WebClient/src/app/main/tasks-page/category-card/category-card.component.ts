import { Component, OnInit, Input } from '@angular/core';
import { CategoryCard } from 'src/shared/models/category-card.model';

@Component({
  selector: 'category-card',
  templateUrl: './category-card.component.html',
  styleUrls: ['./category-card.component.scss']
})

export class CategoryCardComponent implements OnInit {
  @Input() card: CategoryCard;

  constructor() { }

  ngOnInit() {
  }

}
