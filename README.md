# Reed-Muller-Code

## Sources

- [Wiki](https://en.wikipedia.org/wiki/Reed%E2%80%93Muller_code)
- [ComputerPhile pt1](https://www.youtube.com/watch?v=NRv3HMEyuDE)
- [ComputerPhile pt2](https://www.youtube.com/watch?v=CtOCqKpti7s)
- [David F. Brailsford - Building the H5 Reed-Muller Code user by Mariner 9](http://www.eprg.org/computerphile/h5code.pdf)
- [B. Cooke Reed-Muller Error Correcting Codes](http://citeseerx.ist.psu.edu/viewdoc/download?doi=10.1.1.208.440&rep=rep1&type=pdf)
- [S. Raaphorst - Reed-Muller Codes](https://github.com/sraaphorst/reedmuller_py/blob/master/reed_muller.pdf)

## Scenarios

## Doc in ltu:
- https://docs.google.com/document/d/1SBbB5w6oEBluJ5nit1EhOED8v_CEOyatajGp50KbVSw/edit#

This section contains the scenarios this program is able to handle.
For all scenarios, prerequisite step is entering r, m and fault probability.

### 1

1. User enters a message m of fixed length (validated by the application)
2. The application encodes m, shows it.
3. User can choose to edit the the shown encoded message.
4. The program decodes the encoded m, shows it.
