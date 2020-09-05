import { Component, OnInit, OnDestroy } from '@angular/core';
import { Blog } from './models/blog';
import { Subscription } from 'rxjs';
import { BlogService } from './services/blog.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css'],
})
export class BlogsComponent implements OnInit, OnDestroy {
  blogs: Blog[];
  selectedBlog: Blog;
  subscriptions: Subscription[];
  constructor(private blogService: BlogService, private route: Router) {}

  ngOnInit() {
    this.subscriptions = [];
    this.selectedBlog = null;
    this.subscriptions.push(
      this.blogService.getData$().subscribe((res) => {
        this.blogs = res;
      })
    );
  }
  delete(blog: Blog) {
    if (confirm('are you to delete?')) {
      this.blogs.splice(this.blogs.indexOf(blog), 1);
    }
  }

  edit(blog: Blog) {
    this.selectedBlog = blog;
    this.route.navigate(['/blogs/AddEdit', {}]);
  }
  view(blog: Blog) {
    this.selectedBlog = blog;
  }

  ngOnDestroy() {
    this.subscriptions.forEach((subscription) => {
      subscription.unsubscribe();
    });
  }
}
