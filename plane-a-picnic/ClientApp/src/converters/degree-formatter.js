import numeral from 'numeral';

export class DegreeFormatValueConverter {
  toView(value) {
    return numeral(value).format('(0.0)');
  }
}
