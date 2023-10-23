import { Component, OnInit } from '@angular/core';
import { Category } from '../../models/category.model';
import { CategoryService } from '../../services/category.service';

import { FlatTreeControl } from '@angular/cdk/tree';
import {
  MatTreeFlatDataSource,
  MatTreeFlattener,
} from '@angular/material/tree';

@Component({
  selector: 'app-category-tree',
  templateUrl: './category-tree.component.html',
  styleUrls: ['./category-tree.component.css'],
})
export class CategoryTreeComponent implements OnInit {
  constructor(private categoryService: CategoryService) {
    // the flattener that transforms each node to a flat node with level and expandable properties
    this.treeFlattener = new MatTreeFlattener(
      this.transformer,
      this.getLevel,
      this.isExpandable,
      this.getChildren
    );

    // the tree control that manages the expand/collapse state of the nodes
    this.treeControl = new FlatTreeControl<Category>(
      this.getLevel,
      this.isExpandable
    );

    // the data source that provides the data for the tree
    this.dataSource = new MatTreeFlatDataSource(
      this.treeControl,
      this.treeFlattener
    );
  }

  // the properties for the tree component
  treeControl: FlatTreeControl<Category>;
  treeFlattener: MatTreeFlattener<Category, Category>;
  dataSource: MatTreeFlatDataSource<Category, Category>;

  // the variable that holds the categories data
  categories: Category[] = [];

  ngOnInit(): void {
    this.categoryService.getCategories().subscribe((data) => {
      // callin of the recursive function to assign the level property
      this.assignLevel(this.dataSource.data, 0);
      this.dataSource.data = data;
      console.log('data: ', data);
    });
  }

  // the recursive function that assigns a level property to each category based on its depth in the tree
  assignLevel(categories: Category[], level: number) {
    for (let category of categories) {
      category.level = level;
      if (category.subCategories && category.subCategories.length > 0) {
        this.assignLevel(category.subCategories, level + 1);
      }
    }
  }

  // the transformer function that maps each node to a flat node with level and expandable properties
  transformer = (node: Category, level: number) => {
    node.level = level;
    return node;
  };

  // the function that returns the level of a node
  getLevel = (node: Category) => node.level;

  // the function that returns whether a node is expandable or not
  isExpandable = (node: Category) =>
    node.subCategories && node.subCategories.length > 0;

  // the function that returns the children of a node
  getChildren = (node: Category) => node.subCategories;

  // the function that returns whether a node has children or not
  hasChild = (_: number, node: Category) =>
    node.subCategories && node.subCategories.length > 0;
}
