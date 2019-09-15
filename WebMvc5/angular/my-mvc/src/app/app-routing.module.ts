import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BlogsComponent } from './blogs/blogs.component';
import { BlogAddEditComponent } from './blogs/blog-add-edit/blog-add-edit.component';

const routes: Routes = [
  {
    path: '',
    redirectTo: 'blogs',
    pathMatch: 'full'
  },
  {
    path: 'blogs',
    component: BlogsComponent,
    children: [
      {
        path: 'AddEdit',
        component: BlogAddEditComponent
      }
    ]
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule {}
