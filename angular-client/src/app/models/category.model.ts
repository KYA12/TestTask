export interface Category {
  categoryId?: number;
  categoryName?: string;
  parentCategoryId?: number;
  parentCategory?: Category;
  subCategories: Category[];
  level: number; // this is the level of the category in the tree
}
