import { Injectable } from '@angular/core';
import { Blog } from '../models/blog';
import { of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class BlogService {
  constructor() {}

  getData$() {
    const blogs: Blog[] = [];
    for (let index = 0; index < 10; index++) {
      const blog = new Blog();
      blog.Id = index + 1;
      blog.Description = 'ttt' + (index + 1);
      blog.Url = 'tt' + (index + 1);
      blogs.push(blog);
    }

    return of(blogs);
  }
}
