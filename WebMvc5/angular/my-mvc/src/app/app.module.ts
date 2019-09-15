import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { BlogsComponent } from './blogs/blogs.component';
import { BlogDetailComponent } from './blogs/blog-detail/blog-detail.component';
import { BlogAddEditComponent } from './blogs/blog-add-edit/blog-add-edit.component';

@NgModule({
  declarations: [AppComponent, BlogsComponent, BlogDetailComponent, BlogAddEditComponent],
  imports: [BrowserModule, AppRoutingModule],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {}
