import { Component, ElementRef, ViewChild } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpClientModule } from '@angular/common/http';
import { RouterOutlet } from '@angular/router';
import { NgClass, NgFor } from '@angular/common';

export interface TodoItem {
  id: number;
  title: string;
  isDone: boolean;
}

export interface ApiResponse<T> {
  sucess: boolean;
  data: T;
  message: string;
  error?: string;
}

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [RouterOutlet, NgFor, NgClass, HttpClientModule],
})
export class AppComponent {
  todoList: TodoItem[] = [];
  newTask: string = '';
  @ViewChild('todoText') todoInputRef!: ElementRef<HTMLInputElement>;

  constructor(private http: HttpClient) {}

  ngOnInit(): void {
    this.http
      .get<ApiResponse<TodoItem[]>>('http://localhost:5001/api/todo')
      .subscribe({
        next: (respone) => {
          this.todoList = respone.data;
          console.log('Danh sách todo đã được tải:', respone);
        },
        error: (err) => {
          console.error('Lỗi khi lấy danh sách todo:', err);
        },
      });
  }

  addTask(text: string): void {
    if (text.trim() !== '') {
      const newTodoItem = {
        title: text.trim(),
      };
      this.http
        .post<ApiResponse<TodoItem>>(
          'http://localhost:5001/api/todo',
          newTodoItem
        )
        .subscribe({
          next: (respone) => {
            this.todoList.push(respone.data);
            this.todoInputRef.nativeElement.value = '';
          },
          error: (err) => {
            console.error('Lỗi khi thêm todo:', err);
          },
        });
    }
  }

  deleteTask(id: number): void {
    this.http
      .delete<ApiResponse<TodoItem>>(`http://localhost:5001/api/todo/${id}`)
      .subscribe({
        next: (respone) => {
          this.todoList = this.todoList.filter(
            (item) => item.id !== respone.data.id
          );
        },
        error: (err) => {
          console.error('Lỗi khi xóa todo:', err);
        },
      });
  }

  toggleCompleted(id: number): void {
    const todoItem = this.todoList.find((item) => item.id === id);
    if (todoItem) {
      const updated = { title: todoItem.title, isDone: !todoItem.isDone };
      this.http
        .put<ApiResponse<TodoItem>>(
          `http://localhost:5001/api/todo/${id}`,
          updated
        )
        .subscribe({
          next: (respone) => {
            todoItem.isDone = respone.data.isDone;
          },
          error: (err) => {
            console.error('Lỗi khi cập nhật trạng thái todo:', err);
          },
        });
    }
  }

  saveTodoList(): void {
    // Sẽ thay bằng gọi API khi thêm/sửa/xóa
  }
}
