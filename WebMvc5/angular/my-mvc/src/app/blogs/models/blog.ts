export class Blog {
  Id: number;
  Url: string;
  Description: string;
  RowVersion: Int8Array;
  constructor() {
    this.Id = 0;
    this.Url = '';
    this.Description = '';
  }
}
