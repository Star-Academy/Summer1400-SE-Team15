package test.java;

import main.java.IView;
import main.java.SearchEngine;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.extension.ExtendWith;
import org.mockito.junit.jupiter.MockitoExtension;

import static org.mockito.Mockito.mock;

@ExtendWith(MockitoExtension.class)
public class InputScannerTest {

    static final IView viewConsole = mock(IView.class);
    static final SearchEngine searchEngine = mock(SearchEngine.class);

    @Test
    public void ShouldExit(){

    }

}
