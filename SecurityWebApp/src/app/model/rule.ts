export class Rule {
  constructor(
    public enabled: boolean,
    public name: string,
    public type: string,
    public serverity: string,
    public logic: string,
    public notification: string
  ) {}
}
