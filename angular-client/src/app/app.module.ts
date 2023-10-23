import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTreeModule } from '@angular/material/tree';
import { MatIconModule } from '@angular/material/icon';

import { AppComponent } from './app.component';
import { CategoryService } from './services/category.service';
import { CategoryTreeComponent } from './components/category-tree.component/category-tree.component';

@NgModule({
  declarations: [AppComponent, CategoryTreeComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatTreeModule,
    MatIconModule,
  ],
  providers: [CategoryService],
  bootstrap: [AppComponent],
})
export class AppModule {}
