# 📚 ÍNDICE - GUÍA DE ESTUDIO: WEB APIs CON ARQUITECTURA ONION

## PARTE I: FUNDAMENTOS DE WEB APIs

### 1. Conceptos Fundamentales de APIs
#### 1.1 Qué es una API
- Definición y propósito
- Tipos de APIs (REST, GraphQL, SOAP, gRPC)
- Diferencias entre API, Web API y REST API

#### 1.2 Protocolos y Estándares Web
- HTTP/HTTPS fundamentals
- Métodos HTTP (GET, POST, PUT, DELETE, PATCH, OPTIONS)
- Códigos de estado HTTP
- Headers HTTP importantes
- Content-Type y Accept headers

#### 1.3 Arquitectura Cliente-Servidor
- Modelo request-response
- Stateless vs Stateful
- Cacheable responses
- Uniform interface

### 2. REST y Principios RESTful
#### 2.1 Los 6 Principios REST
- Client-Server separation
- Stateless
- Cacheable
- Uniform Interface
- Layered System
- Code on Demand (opcional)

#### 2.2 Diseño de URLs RESTful
- Naming conventions
- Resource identification
- Collection vs Resource endpoints
- Query parameters vs Path parameters
- Versioning strategies

#### 2.3 Richardson Maturity Model
- Level 0: Plain Old XML (POX)
- Level 1: Resources
- Level 2: HTTP Verbs
- Level 3: Hypermedia Controls (HATEOAS)

### 3. Serialización y Formatos de Datos
#### 3.1 JSON
- Estructura y sintaxis
- JSON Schema
- Buenas prácticas de diseño JSON

#### 3.2 XML y otros formatos
- Cuándo usar XML vs JSON
- Content negotiation
- Formatos especializados (YAML, MessagePack)

#### 3.3 Data Transfer Objects (DTOs)
- Propósito y beneficios
- Mapping entre entidades y DTOs
- Validación de DTOs

### 4. Autenticación y Autorización
#### 4.1 Métodos de Autenticación
- Basic Authentication
- API Keys
- JWT (JSON Web Tokens)
- OAuth 2.0 y OpenID Connect

#### 4.2 Autorización
- Role-based Access Control (RBAC)
- Claims-based Authorization
- Policy-based Authorization
- Resource-based Authorization

#### 4.3 Seguridad en APIs
- HTTPS/TLS
- CORS (Cross-Origin Resource Sharing)
- Rate Limiting
- Input validation y sanitization
- SQL Injection prevention
- XSS protection

### 5. Documentación y Testing
#### 5.1 Documentación de APIs
- OpenAPI/Swagger Specification
- API Documentation best practices
- Interactive documentation
- SDK generation

#### 5.2 Testing de APIs
- Unit Testing
- Integration Testing
- Contract Testing
- Load Testing
- Security Testing

---

## PARTE II: ARQUITECTURA ONION - ESTUDIO PROFUNDO

### 6. Fundamentos de Arquitectura Onion
#### 6.1 Historia y Motivación
- Problemas de arquitecturas tradicionales
- Dependency Inversion Principle
- Separation of Concerns
- Testability y maintainability

#### 6.2 Estructura de Capas
- Domain Layer (Core)
- Application Layer (Use Cases)
- Infrastructure Layer
- Presentation Layer (API Controllers)

#### 6.3 Principios SOLID aplicados
- Single Responsibility Principle
- Open/Closed Principle
- Liskov Substitution Principle
- Interface Segregation Principle
- Dependency Inversion Principle

### 7. Domain Layer (Núcleo del Negocio)
#### 7.1 Entities y Value Objects
- Diferencias y cuándo usar cada uno
- Domain Entities vs Data Entities
- Invariants y validaciones de dominio
- Rich Domain Models

#### 7.2 Domain Services
- Cuándo crear domain services
- Orchestration vs Business Logic
- Domain Events

#### 7.3 Repository Patterns
- Interfaces en el dominio
- Specification Pattern
- Unit of Work Pattern

#### 7.4 Aggregate Roots
- Consistency boundaries
- Transaction boundaries
- Loading strategies

### 8. Application Layer (Casos de Uso)
#### 8.1 Use Cases y Application Services
- Command Query Responsibility Segregation (CQRS)
- Command Handlers
- Query Handlers
- Application Services vs Domain Services

#### 8.2 DTOs y Mapping
- Input/Output DTOs
- AutoMapper vs Manual Mapping
- Validation strategies

#### 8.3 Cross-cutting Concerns
- Logging
- Caching
- Transaction management
- Error handling

### 9. Infrastructure Layer (Detalles Técnicos)
#### 9.1 Data Access
- Entity Framework / ORM patterns
- Repository implementations
- Database migrations
- Connection management

#### 9.2 External Services Integration
- HTTP clients
- Message queues
- File systems
- Third-party APIs

#### 9.3 Configuration y Dependency Injection
- IoC containers
- Configuration management
- Environment-specific settings

### 10. Dependency Injection y IoC
#### 10.1 Conceptos Fundamentales
- Inversion of Control containers
- Dependency Injection patterns
- Service lifetimes (Singleton, Transient, Scoped)

#### 10.2 Registration Strategies
- Convention-based registration
- Assembly scanning
- Conditional registrations

#### 10.3 Advanced DI Patterns
- Decorator Pattern
- Factory Pattern
- Service Locator (anti-pattern)

---

## PARTE III: WEB APIs CON ARQUITECTURA ONION

### 11. Estructura del Proyecto
#### 11.1 Organización de Proyectos
- Naming conventions
- Project dependencies
- Shared projects y common libraries

#### 11.2 Startup Configuration
- Service registration
- Middleware pipeline
- Configuration binding

#### 11.3 Environment Management
- Development vs Production settings
- Secrets management
- Feature flags

### 12. Controllers y Presentation Layer
#### 12.1 API Controllers Design
- Action methods patterns
- Model binding
- Action filters
- Custom attributes

#### 12.2 Error Handling
- Global exception handling
- Custom exceptions
- Problem Details (RFC 7807)
- Logging strategies

#### 12.3 Response Formatting
- Content negotiation
- Custom formatters
- Compression
- Caching headers

### 13. Middleware y Pipeline
#### 13.1 Built-in Middleware
- Authentication middleware
- Authorization middleware
- CORS middleware
- Static files middleware

#### 13.2 Custom Middleware
- Creating custom middleware
- Middleware ordering
- Conditional middleware

#### 13.3 Request/Response Manipulation
- Request logging
- Response transformation
- Performance monitoring

### 14. Validation y Data Binding
#### 14.1 Model Validation
- Data Annotations
- FluentValidation
- Custom validators
- Client-side validation

#### 14.2 Model Binding
- Simple type binding
- Complex type binding
- Custom model binders
- Binding from different sources

#### 14.3 Input Sanitization
- XSS prevention
- SQL injection prevention
- Input normalization

### 15. Testing en Arquitectura Onion
#### 15.1 Unit Testing Strategy
- Testing domain logic
- Mocking dependencies
- Test data builders
- Property-based testing

#### 15.2 Integration Testing
- Testing API endpoints
- Database integration tests
- External service mocking
- Contract testing

#### 15.3 End-to-End Testing
- API testing frameworks
- Test environments
- Data seeding strategies
- Performance testing

### 16. Performance y Optimización
#### 16.1 Caching Strategies
- Memory caching
- Distributed caching
- HTTP caching
- Cache invalidation

#### 16.2 Database Optimization
- Query optimization
- Connection pooling
- Read replicas
- Indexing strategies

#### 16.3 Scalability Patterns
- Horizontal vs Vertical scaling
- Load balancing
- Microservices considerations
- Event-driven architecture

### 17. Monitoring y Observability
#### 17.1 Logging
- Structured logging
- Log levels y filtering
- Centralized logging
- Correlation IDs

#### 17.2 Metrics y Monitoring
- Application metrics
- Business metrics
- Health checks
- Performance counters

#### 17.3 Distributed Tracing
- Request tracing
- Correlation across services
- Error tracking
- Performance analysis

---

## PARTE IV: CASOS DE ESTUDIO Y PROYECTOS PRÁCTICOS

### 18. Proyecto 1: Sistema de E-commerce
#### 18.1 Análisis de Dominio
- Product Catalog
- Shopping Cart
- Order Management
- Payment Processing
- Inventory Management

#### 18.2 Implementación por Capas
- Domain modeling
- Use cases implementation
- Infrastructure setup
- API endpoints design

#### 18.3 Características Avanzadas
- Search functionality
- Recommendation engine
- Multi-tenancy
- Internationalization

### 19. Proyecto 2: Sistema de Banking
#### 19.1 Análisis de Dominio
- Account management
- Transaction processing
- Transfer operations
- Audit trails
- Compliance requirements

#### 19.2 Seguridad Avanzada
- Multi-factor authentication
- Transaction signing
- Fraud detection
- Regulatory compliance

#### 19.3 Event Sourcing
- Event store implementation
- Projections
- Snapshots
- Replay capabilities

### 20. Proyecto 3: Sistema de Healthcare
#### 20.1 Análisis de Dominio
- Patient management
- Medical records
- Appointment scheduling
- Treatment tracking
- HIPAA compliance

#### 20.2 Integration Patterns
- HL7 FHIR standards
- Legacy system integration
- Real-time notifications
- Mobile app support

#### 20.3 Data Privacy y Security
- Encryption at rest and in transit
- Access logging
- Data anonymization
- Consent management