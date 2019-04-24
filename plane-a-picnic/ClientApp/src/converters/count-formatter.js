import numeral from 'numeral';

export class CountFormatValueConverter {
  toView(value) {
    return numeral(value).format('(0,0)');
  }
}
